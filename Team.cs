using System;
using System.Collections;
using System.Linq;

namespace scudetto_italy 
{
        public enum Team
        {
            Roma,
            Juventus,
            Milan,
            Napoli,
            Torino,
            Inter,
            Atalanta,
            Udinese,
            Fiorentina,
            Bologna,
            Sassuolo,
            Verona, 
            Sampdoria,
            Salernitana, 
            Spezia,
            Cremoneze,
            Empoli,
            Lecce,
            Monza,
            Lazio
        }

        public static class FootballClubInfo
        {
            public const int Count = 6;

            public static IEnumerable Items
            {
                get
                {
                    return Enum.GetValues(typeof(Team)).Cast<Team>();
                }
            }

            public static string GetName(Team footballClub)
            {
                switch (footballClub)
                {
                    case Team.Roma:
                        return "Roma";
                    case Team.Juventus:
                        return "Juventus";
                    case Team.Milan:
                        return "Milan";
                    case Team.Napoli:
                        return "Napoli";
                    case Team.Torino:
                        return "Torino";
                    case Team.Atalanta:
                        return "Atalanta";
                    case Team.Inter:
                        return "Inter";
                    case Team.Udinese:
                        return "Udinese";
                    case Team.Fiorentina:
                        return "Fiorentina";
                    case Team.Bologna:
                        return "Bologna";
                    case Team.Sassuolo:
                        return "Sassuolo";
                    case Team.Verona:
                        return "Verona";
                    case Team.Sampdoria:
                        return "Sampdoria";
                    case Team.Salernitana:
                        return "Salernitana";
                    case Team.Spezia:
                        return "Spezia";
                    case Team.Cremoneze:
                        return "Cremoneze";
                    case Team.Empoli:
                        return "Empoli";
                    case Team.Lecce:
                        return "Lecce";
                    case Team.Monza:
                        return "Monza";
                    case Team.Lazio:
                        return "Lazio";
                    default:
                        return "";
                }
            }
        }
}
