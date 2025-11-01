using RestaurantMenuAPI.Models.Enums;

namespace RestaurantMenuAPI.Helpers
{
    public class CategoryHelper
    {
        public static string GetDisplayName(Enum category)
        {
            return category switch
            {
                Category.Entradas => "Entradas",
                Category.Picadas => "Picadas",
                Category.PlatosPrincipales => "Platos principales",
                Category.Pastas => "Pastas",
                Category.Carnes => "Carnes",
                Category.PescadosYMariscos => "Pescados y mariscos",
                Category.Minutas => "Minutas",
                Category.Ensaladas => "Ensaladas",
                Category.Guarniciones => "Guarniciones",
                Category.Postres => "Postres",

                Category.Hamburguesas => "Hamburguesas",
                Category.Pizzas => "Pizzas",
                Category.Empanadas => "Empanadas",
                Category.Sandwiches => "Sándwiches",
                Category.PapasYAcompanamientos => "Papas y acompañamientos",
                Category.Combos => "Combos",
                Category.MenusDelDia => "Menús del día",

                Category.Desayunos => "Desayunos",
                Category.Meriendas => "Meriendas",
                Category.Cafes => "Cafés",
                Category.TesEInfusiones => "Tés e infusiones",
                Category.PanaderiaYPasteleria => "Panadería y pastelería",
                Category.LicuadosYJugos => "Licuados y jugos",
                Category.TartasYTortas => "Tartas y tortas",

                Category.TragosClasicos => "Tragos clásicos",
                Category.TragosDeAutor => "Tragos de autor",
                Category.Shooters => "Shots / Shooters",
                Category.CervezasTiradas => "Cervezas tiradas",
                Category.CervezasArtesanales => "Cervezas artesanales",
                Category.Vinos => "Vinos",
                Category.Aperitivos => "Aperitivos",
                Category.BebidasSinAlcohol => "Bebidas sin alcohol",

                SpecialCategory.Promociones => "Promociones",
                SpecialCategory.MenuInfantil => "Menú infantil",
                SpecialCategory.MenuEjecutivo => "Menú ejecutivo",
                SpecialCategory.MenuSinTacc => "Menú sin TACC",
                SpecialCategory.Vegano => "Vegano",
                SpecialCategory.Vegetariano => "Vegetariano",
                SpecialCategory.EspecialesDelDia => "Especiales del día",

                //_ => category.ToString()
            };
        }
    }
}
