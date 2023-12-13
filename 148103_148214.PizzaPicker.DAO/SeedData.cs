using _148103_148214.PizzaPicker.CORE;
using _148103_148214.PizzaPicker.INTERFACES.DaoInterfaces;

namespace _148103_148214.PizzaPicker.DAO
{
    internal static class SeedData
    {
        public static IEnumerable<IPizza> GetPizzas()
        {
            var pizzas = new List<Pizza>()
            {
                new Pizza() { Id = 1, Ingridients = "upon, animal, yard, product, get", Name = "Large Pizza", PizzeriaId = 14, Dough = DoughType.Thin },
new Pizza() { Id = 2, Ingridients = "gun, article, air, national, mention", Name = "Choice Pizza", PizzeriaId = 20, Dough = DoughType.Thick },
new Pizza() { Id = 3, Ingridients = "no, common, investment", Name = "Marriage Pizza", PizzeriaId = 4, Dough = DoughType.Thick },
new Pizza() { Id = 4, Ingridients = "voice, organization, speak, knowledge, thousand", Name = "West Pizza", PizzeriaId = 11, Dough = DoughType.Thin },
new Pizza() { Id = 5, Ingridients = "hold, chair, thought", Name = "Surface Pizza", PizzeriaId = 12, Dough = DoughType.Thick },
new Pizza() { Id = 6, Ingridients = "be, responsibility, firm, grow", Name = "Shoulder Pizza", PizzeriaId = 3, Dough = DoughType.Thick },
new Pizza() { Id = 7, Ingridients = "example, second, father", Name = "Thank Pizza", PizzeriaId = 18, Dough = DoughType.Thin },
new Pizza() { Id = 8, Ingridients = "off, pattern, call, challenge, after", Name = "Especially Pizza", PizzeriaId = 6, Dough = DoughType.Thin },
new Pizza() { Id = 9, Ingridients = "become, federal, collection, system, all", Name = "Eye Pizza", PizzeriaId = 11, Dough = DoughType.Thin },
new Pizza() { Id = 10, Ingridients = "put, hospital, and, live", Name = "Ball Pizza", PizzeriaId = 20, Dough = DoughType.Thick },
new Pizza() { Id = 11, Ingridients = "police, your, rise, five", Name = "Adult Pizza", PizzeriaId = 5, Dough = DoughType.Thick },
new Pizza() { Id = 12, Ingridients = "white, animal, pressure", Name = "Program Pizza", PizzeriaId = 16, Dough = DoughType.Thick },
new Pizza() { Id = 13, Ingridients = "beat, although, conference, war", Name = "Fire Pizza", PizzeriaId = 11, Dough = DoughType.Thin },
new Pizza() { Id = 14, Ingridients = "sure, know", Name = "Hold Pizza", PizzeriaId = 10, Dough = DoughType.Thick },
new Pizza() { Id = 15, Ingridients = "add, clear, leader, process", Name = "Help Pizza", PizzeriaId = 2, Dough = DoughType.Thin },
            new Pizza() { Id = 16, Ingridients = "bank, get, least, of, change", Name = "Rock Pizza", PizzeriaId = 7, Dough = DoughType.Thin },
new Pizza() { Id = 17, Ingridients = "base, her", Name = "Law Pizza", PizzeriaId = 1, Dough = DoughType.Thin },
new Pizza() { Id = 18, Ingridients = "listen, school, drop, popular", Name = "A Pizza", PizzeriaId = 12, Dough = DoughType.Thick },
new Pizza() { Id = 19, Ingridients = "TV, of, challenge, create", Name = "Manage Pizza", PizzeriaId = 11, Dough = DoughType.Thick },
new Pizza() { Id = 20, Ingridients = "current, kid, same, other, word", Name = "Soon Pizza", PizzeriaId = 20, Dough = DoughType.Thick },
new Pizza() { Id = 21, Ingridients = "baby, great", Name = "Cell Pizza", PizzeriaId = 1, Dough = DoughType.Thin },
new Pizza() { Id = 22, Ingridients = "first, alone, store, next, charge", Name = "Case Pizza", PizzeriaId = 10, Dough = DoughType.Thick },
new Pizza() { Id = 23, Ingridients = "well, drop, maintain, at", Name = "Sit Pizza", PizzeriaId = 12, Dough = DoughType.Thin },
new Pizza() { Id = 24, Ingridients = "believe, daughter, year, technology, including", Name = "Thought Pizza", PizzeriaId = 5, Dough = DoughType.Thin },
new Pizza() { Id = 25, Ingridients = "owner, some", Name = "Thank Pizza", PizzeriaId = 13, Dough = DoughType.Thick },
new Pizza() { Id = 26, Ingridients = "paper, until, yard, partner, story", Name = "Establish Pizza", PizzeriaId = 15, Dough = DoughType.Thick },
new Pizza() { Id = 27, Ingridients = "yard, evidence, difficult, mother", Name = "Structure Pizza", PizzeriaId = 10, Dough = DoughType.Thick },
new Pizza() { Id = 28, Ingridients = "heavy, compare", Name = "Money Pizza", PizzeriaId = 13, Dough = DoughType.Thick },
new Pizza() { Id = 29, Ingridients = "something, on, we, bad, ever", Name = "Image Pizza", PizzeriaId = 16, Dough = DoughType.Thick },
new Pizza() { Id = 30, Ingridients = "fall, parent, clearly", Name = "Size Pizza", PizzeriaId = 20, Dough = DoughType.Thick },
new Pizza() { Id = 31, Ingridients = "her, speech, professor, worker, floor", Name = "Call Pizza", PizzeriaId = 1, Dough = DoughType.Thin },
new Pizza() { Id = 32, Ingridients = "table, message", Name = "Already Pizza", PizzeriaId = 9, Dough = DoughType.Thin },
new Pizza() { Id = 33, Ingridients = "action, receive", Name = "Group Pizza", PizzeriaId = 8, Dough = DoughType.Thick },
new Pizza() { Id = 34, Ingridients = "team, whether, my, nor, page", Name = "Have Pizza", PizzeriaId = 9, Dough = DoughType.Thick },
new Pizza() { Id = 35, Ingridients = "down, trip, top, although", Name = "Manage Pizza", PizzeriaId = 17, Dough = DoughType.Thick },
new Pizza() { Id = 36, Ingridients = "left, across, ago", Name = "Land Pizza", PizzeriaId = 12, Dough = DoughType.Thick },
new Pizza() { Id = 37, Ingridients = "phone, identify, media, take", Name = "Stock Pizza", PizzeriaId = 16, Dough = DoughType.Thin },
new Pizza() { Id = 38, Ingridients = "guy, budget, happen", Name = "Agree Pizza", PizzeriaId = 1, Dough = DoughType.Thin },
new Pizza() { Id = 39, Ingridients = "knowledge, street, space, arrive, rule", Name = "Nice Pizza", PizzeriaId = 18, Dough = DoughType.Thick },
new Pizza() { Id = 40, Ingridients = "yourself, ahead, on, letter, culture", Name = "Light Pizza", PizzeriaId = 9, Dough = DoughType.Thin }
            };
            return pizzas;
        }
        public static IEnumerable<IPizzeria> GetPizzerias()
        {
            var pizzerias = new List<Pizzeria>()
            {
            new Pizzeria() { Id = 1, Address = "242 Collins Forks, East Mark, DC 24194", Name = "Then Pizzeria", SupportedPostalCodes = "95814" },
            new Pizzeria() { Id = 2, Address = "2337 William Loop Suite 071, Wagnerport, MI 82800", Name = "Month Pizzeria", SupportedPostalCodes = "67490" },
 new Pizzeria() { Id = 3, Address = "USNS Shannon, FPO AE 63899", Name = "Type Pizzeria", SupportedPostalCodes = "08210" },
 new Pizzeria() { Id = 4, Address = "9297 Briggs Springs, Nicholasborough, GA 40793", Name = "Drop Pizzeria", SupportedPostalCodes = "10460" },
 new Pizzeria() { Id = 5, Address = "PSC 1454, Box 9604, APO AE 60502", Name = "Computer Pizzeria", SupportedPostalCodes = "94654" },
 new Pizzeria() { Id = 6, Address = "886 Avila Mews Suite 213, Hansonland, TN 89649", Name = "Debate Pizzeria", SupportedPostalCodes = "66282" },
 new Pizzeria() { Id = 7, Address = "490 Christina Estate, New Nancyhaven, TX 86863", Name = "Notice Pizzeria", SupportedPostalCodes = "44034" },
 new Pizzeria() { Id = 8, Address = "3667 Craig Inlet Suite 438, North Brett, LA 95412", Name = "Recent Pizzeria", SupportedPostalCodes = "27868" },
 new Pizzeria() { Id = 9, Address = "046 Nelson Creek, West Catherine, NH 18398", Name = "Interest Pizzeria", SupportedPostalCodes = "02526" },
 new Pizzeria() { Id = 10, Address = "54733 Duran Views Suite 124, Devonshire, SC 02449", Name = "Purpose Pizzeria", SupportedPostalCodes = "84411" },
 new Pizzeria() { Id = 11, Address = "2379 Melissa Mount, Thompsonside, WV 60414", Name = "Buy Pizzeria", SupportedPostalCodes = "33270" },
 new Pizzeria() { Id = 12, Address = "275 Whitney Green Apt. 967, Rachelton, AZ 61188", Name = "Behind Pizzeria", SupportedPostalCodes = "50553" },
 new Pizzeria() { Id = 13, Address = "Unit 2478 Box 9424, DPO AE 38056", Name = "Full Pizzeria", SupportedPostalCodes = "28840" },
 new Pizzeria() { Id = 14, Address = "919 Mathews Manors, Port Kristyville, WV 87773", Name = "Society Pizzeria", SupportedPostalCodes = "92220" },
 new Pizzeria() { Id = 15, Address = "558 Craig Highway Suite 683, Simsborough, WI 12796", Name = "Computer Pizzeria", SupportedPostalCodes = "62239" },
 new Pizzeria() { Id = 16, Address = "989 Jay Dam Suite 041, North Markfurt, IN 23443", Name = "Strategy Pizzeria", SupportedPostalCodes = "56900" },
 new Pizzeria() { Id = 17, Address = "67870 Kelly Estate, Jessicafort, PA 92746", Name = "Deep Pizzeria", SupportedPostalCodes = "04247" },
 new Pizzeria() { Id = 18, Address = "013 Dominique Lane Apt. 235, Samanthashire, KS 58192", Name = "Class Pizzeria", SupportedPostalCodes = "52583" },
 new Pizzeria() { Id = 19, Address = "175 Cheryl Course Apt. 205, Ashleybury, FL 28493", Name = "Sense Pizzeria", SupportedPostalCodes = "18010" },
 new Pizzeria() { Id = 20, Address = "025 Price Manor, Richardchester, DE 71331", Name = "Over Pizzeria", SupportedPostalCodes = "24659" }

};
            return pizzerias;
        }
    }
}
