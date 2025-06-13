using A_journey_through_miniature_Uzhhorod.Database.Models;
using A_journey_through_miniature_Uzhhorod.Database.Models.Translation;
using A_journey_through_miniature_Uzhhorod.MVVM.Model;
using System.IO;
using System.Text.Json;

namespace A_journey_through_miniature_Uzhhorod.Database
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            var jsonFilePath = "Database/Data/data.json";
            if (!File.Exists(jsonFilePath))
            {
                Console.WriteLine("❌ Файл data.json не знайдено.");
                return;
            }

            string jsonData;
            try
            {
                jsonData = File.ReadAllText(jsonFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Помилка читання файлу: {ex.Message}");
                return;
            }

            SeedData? data;
            try
            {
                data = JsonSerializer.Deserialize<SeedData>(jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Помилка десеріалізації JSON: {ex.Message}");
                Console.WriteLine($"📂 Вміст JSON: {jsonData}");
                return;
            }

            if (data == null)
            {
                Console.WriteLine("❌ Десеріалізація JSON повернула null.");
                return;
            }

            data.Miniatures ??= new List<MiniatureSeed>();
            data.Quests ??= new List<QuestSeed>();
            data.Events ??= new List<EventSeed>();
            data.Achievements ??= new List<AchievementSeed>();

            Console.WriteLine($"🟢 JSON завантажено: {data.Miniatures.Count} мініатюр, {data.Quests.Count} квестів, {data.Events.Count} подій, {data.Achievements.Count} досягнень.");

            if (!context.Miniatures.Any())
            {
                var miniatures = data.Miniatures.Select(m => new Miniature
                {
                    Latitude = m.Latitude,
                    Longitude = m.Longitude,
                    ImageUrl = m.ImageUrl,
                    ModelUrl = m.ModelUrl,
                    Translations = m.Translations?
                        .Where(t => !string.IsNullOrWhiteSpace(t.LanguageCode))
                        .Select(t => new MiniatureTranslation
                        {
                            LanguageCode = t.LanguageCode.Trim().ToLower(),
                            Name = t.Name,
                            Description = t.Description
                        }).ToList() ?? new List<MiniatureTranslation>()
                }).ToList();

                context.Miniatures.AddRange(miniatures);
                context.SaveChanges();
            }

            var questTypeToEntity = new Dictionary<string, Quest>();
            if (!context.Quests.Any())
            {
                Console.WriteLine("🟢 Квести відсутні, додаємо...");

                var quests = data.Quests.Select(q =>
                {
                    var quest = new Quest
                    {
                        Type = q.Type,
                        TargetCount = q.TargetCount,
                        IconName = q.IconName,
                        Translations = q.Translations?
                            .Where(t => t != null)
                            .Select(t => new QuestTranslation
                            {
                                LanguageCode = t.LanguageCode,
                                Title = t.Title,
                                Description = t.Description
                            }).ToList() ?? new List<QuestTranslation>()
                    };

                    questTypeToEntity[q.Type] = quest;
                    return quest;
                }).ToList();

                context.Quests.AddRange(quests);
                context.SaveChanges();

                foreach (var seed in data.Quests)
                {
                    if (!string.IsNullOrWhiteSpace(seed.ParentQuestType))
                    {
                        var child = context.Quests.FirstOrDefault(q => q.Type == seed.Type);
                        var parent = context.Quests.FirstOrDefault(q => q.Type == seed.ParentQuestType);
                        if (child != null && parent != null)
                        {
                            child.ParentQuestId = parent.Id;
                        }
                    }
                }

                context.SaveChanges();

                Console.WriteLine($"✅ Додано {quests.Count} квестів із деревом.");
            }
            else
            {
                var existing = context.Quests.ToList();
                foreach (var q in existing)
                {
                    questTypeToEntity[q.Type] = q;
                }

                Console.WriteLine("⏭ Квести вже існують.");
            }

            if (!context.Achievements.Any())
            {
                Console.WriteLine("🟢 Досягнення відсутні, додаємо...");

                var achievements = data.Achievements.Select(a =>
                {
                    if (!questTypeToEntity.TryGetValue(a.QuestType, out var quest))
                    {
                        Console.WriteLine($"⚠ Не знайдено квесту з типом '{a.QuestType}' для досягнення.");
                        return null;
                    }

                    return new Achievement
                    {
                        IconName = a.IconName,
                        IsSecret = a.IsSecret,
                        QuestId = quest.Id,
                        Translations = a.Translations.Select(t => new AchievementTranslation
                        {
                            LanguageCode = t.LanguageCode,
                            Title = t.Title,
                            Description = t.Description
                        }).ToList()
                    };
                }).Where(a => a != null).ToList()!;

                context.Achievements.AddRange(achievements);
                context.SaveChanges();

                Console.WriteLine($"✅ Додано {achievements.Count} досягнень.");
            }
            else
            {
                Console.WriteLine("⏭ Досягнення вже існують.");
            }


            if (!context.Events.Any())
            {
                Console.WriteLine("🟢 Події відсутні, додаємо...");

                var events = data.Events.Select(e => new Event
                {
                    EventDate = e.EventDate,
                    Translations = e.Translations?
                        .Where(t => t != null)
                        .Select(t => new EventTranslation
                        {
                            LanguageCode = t.LanguageCode,
                            Title = t.Title,
                            Description = t.Description
                        }).ToList() ?? new List<EventTranslation>()
                }).ToList();

                context.Events.AddRange(events);
                Console.WriteLine($"✅ Додано {events.Count} подій.");
            }
            else
            {
                Console.WriteLine("⏭ Події вже існують.");
            }

            try
            {
                context.SaveChanges();
                Console.WriteLine("✅ Початкові дані успішно завантажені!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Помилка при збереженні даних: {ex.Message}");
            }

            //адмін
            if (!context.Users.Any(u => u.Role == UserRole.Admin))
            {
                Console.WriteLine("🛠️ Створюємо дефолтного адміністратора...");

                var admin = new User
                {
                    Username = "admin",
                    Email = "admin@example.com",
                    PasswordHash = PasswordHelper.HashPassword("Adm1n1strator"), // 🔐 заміни пізніше
                    Role = UserRole.Admin,
                    CreatedAt = DateTime.UtcNow
                };

                context.Users.Add(admin);
                context.SaveChanges();

                Console.WriteLine("✅ Додано адміністратора: admin / admin123");
            }
            else
            {
                Console.WriteLine("⏭ Адміністратор вже існує.");
            }

        }

        public class SeedData
        {
            public List<MiniatureSeed> Miniatures { get; set; }
            public List<QuestSeed> Quests { get; set; }
            public List<EventSeed> Events { get; set; }
            public List<AchievementSeed> Achievements { get; set; }
        }

        public class MiniatureSeed
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string ImageUrl { get; set; }
            public string? ModelUrl { get; set; }
            public List<MiniatureTranslationSeed> Translations { get; set; }
        }

        public class MiniatureTranslationSeed
        {
            public string LanguageCode { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class QuestSeed
        {
            public string Type { get; set; }
            public int TargetCount { get; set; }
            public string? ParentQuestType { get; set; }
            public string? IconName { get; set; }
            public List<QuestTranslationSeed> Translations { get; set; }
        }

        public class QuestTranslationSeed
        {
            public string LanguageCode { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }

        public class EventSeed
        {
            public DateTime EventDate { get; set; }
            public List<EventTranslationSeed> Translations { get; set; }
        }

        public class EventTranslationSeed
        {
            public string LanguageCode { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }

        public class AchievementSeed
        {
            public string QuestType { get; set; } = string.Empty; // 🔄 замість QuestId
            public string IconName { get; set; } = "Trophy";
            public bool IsSecret { get; set; } = false;
            public List<AchievementTranslationSeed> Translations { get; set; } = new();
        }


        public class AchievementTranslationSeed
        {
            public string LanguageCode { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }
    }
}
