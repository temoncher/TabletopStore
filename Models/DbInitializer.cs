using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabletopStore.Models
{
    /// <summary>
    /// Categories are extracted into another property,
    /// cause we need to set up connection between games and categories,
    /// so we want to assign a particular cateogry for each item,
    /// without using Categories.Last() or Categories.First(), like we did in Mock classes.
    /// </summary>
    public class DbInitializer
    {
        public static void Seed(StoreDBContext context)
        {
            context.Database.EnsureCreated();
            //Seeding categories
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            //Calling a method to seed games
            SeedGames(context);
        }

        private static void SeedGames(StoreDBContext context)
        {
            //Searched the whole internet for tabletop games discriptions, but didn't find any :)
            if (!context.Games.Any())
            {
                context.AddRange(
                        new Game()
                        {
                            Name = "Уно",
                            ShortDescription = "Игра, которая способна увлечь кого угодно",
                            LongDescription = "«Уно» — это одна из самых известных и увлекательных карточных игр. Когда вы хотите отлично провести время в компании или же скоротать время в путешествии, «Уно» станет лучшим вариантом для крупной компании: обычные карточные игры становятся неинтересными при игре уже впятером, а вот «Уно» вполне нормально и динамично играется, даже если участвует десять человек.",
                            PrefferedAge = 7,
                            MaxPlayers = 10,
                            MinPlayers = 2,
                            Time = 20,
                            Price = 449.99,
                            ImageUrl = "https://yar.mosigra.ru/mosigra.product.main/525/575/IMG_5122_800x500.jpg",
                            ImageThumbnailUrl = "https://cdn.mosigra.ru/mosigra.product.box/525/572/IMG_5119_mini_200x170.jpg",
                            AmountInStock = 100,
                            IsHit = true,
                            Category = Categories["Реакция"]
                        },
                        new Game()
                        {
                            Name = "Шакал",
                            ShortDescription = "Карррамба! Это просто хит!",
                            LongDescription = "Этот «Шакал» — всё та же замечательная стратегия родом из МГУ 70-х, ставшая бестселлером в нашей стране и лучшей стратегией 2012 года. Вы командуете отважными пиратами, которые высаживаются на остров в поисках сокровищ. Задача — найти золото и перетащить его к себе на корабль. Остров состоит из клеток, на каждой из которых что-то происходит: можно найти форт, пушку, встретить крокодила, обнаружить бутылку с посланием или откопать один из кладов капитана Шакала.",
                            PrefferedAge = 8,
                            MaxPlayers = 4,
                            MinPlayers = 2,
                            Time = 90,
                            Price = 1999.99,
                            ImageUrl = "https://yar.mosigra.ru/mosigra.product.main/533/782/DSC_0135_800x500.jpg",
                            ImageThumbnailUrl = "https://cdn.mosigra.ru/mosigra.product.box/535/751/shakal_podzem_200x170.jpg",
                            AmountInStock = 100,
                            IsHit = true,
                            Category = Categories["Логика"]
                        },
                        new Game()
                        {
                            Name = "Вулкан",
                            ShortDescription = "Большой бум!",
                            LongDescription = "Островитяне никогда не поднимались на вершину горы, остерегаясь пробудить злого бога огня, но однажды, презрев все запреты, молодой туземец добрался до пышущего жаром кратера и бросил в него огромный камень. И вулкан проснулся: затряс землю, напугав жителей, пролился потоками горячей лавы. Островитяне заметались по берегу, отыскивая всё, что сгодится в борьбе. В борьбе за выживание сгодится всё: и каменные стены, и тюки с соломой, и бревенчатые заборы. Ну а хитрые тактики отводят потоки лавы в сторону от деревни: и устранение конкурентов, и спасение. Увлекательное противостояние силам природы сочетается с захватывающими сражениями против соседей, фактор удачи в виде бросков кубика добавляет азарта и непредсказуемости, делая игру яркой и самобытной.",
                            PrefferedAge = 10,
                            MaxPlayers = 6,
                            MinPlayers = 2,
                            Time = 45,
                            Price = 1499.99,
                            ImageUrl = "https://yar.mosigra.ru/mosigra.product.main/543/598/DSC_0702_800x500.jpg",
                            ImageThumbnailUrl = "https://cdn.mosigra.ru/mosigra.product.box/543/596/1_200x170.jpg",
                            AmountInStock = 40,
                            IsHit = false,
                            Category = Categories["Логика"]
                        },
                        new Game()
                        {
                            Name = "Кодовые имена",
                            ShortDescription = "Опасные ассоциации",
                            LongDescription = "Кодовые имена — это командная игра, в которой капитаны шпионских организаций помогают своим отыскать всех тайных агентов. Она необычная и достаточно простая, поэтому затягивает на несколько часов, хотя можно успеть и за тридцать минут. Всё зависит от догадливости команды и умения капитана правильно подобрать общую ассоциацию. А, кстати, среди персонажей попадаются мирные люди, двойные агенты и злобный убийца — вот его лучше ни за что не находить, отмена операции, отмена операции! Игра необычная и достаточно простая, поэтому затягивает на несколько часов. Не зря она стала игрой года в 2017.",
                            PrefferedAge = 10,
                            MaxPlayers = 8,
                            MinPlayers = 2,
                            Time = 20,
                            Price = 1249.99,
                            ImageUrl = "https://yar.mosigra.ru/mosigra.product.main/555/302/DSC_3489_800x500.jpg",
                            ImageThumbnailUrl = "https://cdn.mosigra.ru/mosigra.product.box/555/299/1_200x170.jpg",
                            AmountInStock = 33,
                            IsHit = false,
                            Category = Categories["Логика"]
                        },
                        new Game()
                        {
                            Name = "Свинтус",
                            ShortDescription = "Воспитание внутренней свиньи начнется прямо сейчас!",
                            LongDescription = "Перед вами – новое самостоятельное издание «Свинтуса», игры дружеских компаний, офисных сотрудников и просто людей, умеющих искренне и с чувством делать друг другу гадости. В основе «Свинтуса» – принцип, на котором основано множество игр, включая легендарную «Уно». Сбрасывая с руки карты на игровой кон, вы должны повторить либо цвет, либо достоинство лежащей сверху карты. Либо сыграть одну из специальных карт – и вот тут есть где подложить свинью другу! Согласитесь, игровая механика проста и понятна, ну, а уж нравственные устои, на которых зиждется «Свинтус» - интуитивны и близки любому, кто хотя бы пару часов провел в человеческом коллективе.",
                            PrefferedAge = 8,
                            MaxPlayers = 10,
                            MinPlayers = 2,
                            Time = 15,
                            Price = 389.99,
                            ImageUrl = "https://yar.mosigra.ru/mosigra.product.main/520/650/1-3_800x500.jpg",
                            ImageThumbnailUrl = "https://cdn.mosigra.ru/mosigra.product.box/520/661/1-mini_200x170.jpg",
                            AmountInStock = 67,
                            IsHit = false,
                            Category = Categories["Реакция"]
                        },
                        new Game()
                        {
                            Name = "Медвед",
                            ShortDescription = "Игра с шишкой. Абсолютный хит.",
                            LongDescription = "Самое сложное в правилах — это перемешивание карт. Самое увлекательное — это «Летающий Превед». Самое классное — это сбросить все карты и оказаться победителем.",
                            PrefferedAge = 6,
                            MaxPlayers = 10,
                            MinPlayers = 3,
                            Time = 20,
                            Price = 989.99,
                            ImageUrl = "https://www.mosigra.ru/mosigra.product.main/533/956/DSC_0586_800x500.jpg",
                            ImageThumbnailUrl = "https://cdn.mosigra.ru/mosigra.product.box/535/261/medved_1_200x170.JPG",
                            AmountInStock = 34,
                            IsHit = false,
                            Category = Categories["Реакция"]
                        }
                    );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Category> categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var catList = new Category[]
                    {
                        new Category(){ Name="Логика", Description="Игра, которая проверяет на прочность твое логическое мышление."},
                        new Category(){ Name="Реакция", Description="Игра для тех, кто быстрее ветра! А также для тех, кто не боится бросить вызвов своим друзьям!"}
                    };
                    categories = new Dictionary<string, Category>();

                    foreach (Category cat in catList)
                    {
                        categories.Add(cat.Name, cat);
                    }
                }

                return categories;
            }
        }
    }
}
