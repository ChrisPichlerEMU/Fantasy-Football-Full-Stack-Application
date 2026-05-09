namespace FantasyFootball.Models.QueryParameters.ApiSports;

public class ApiSportsTeam(string queryValue) : QueryParameter(ApiSportsTeamQueryKey, queryValue)
{
    private const string ApiSportsTeamQueryKey = "team";

    public static readonly ApiSportsTeam LasVegasRaiders = new("1");
    public static readonly ApiSportsTeam JacksonvilleJaguars = new("2");
    public static readonly ApiSportsTeam NewEnglandPatriots = new("3");
    public static readonly ApiSportsTeam NewYorkGiants = new("4");
    public static readonly ApiSportsTeam BaltimoreRavens = new("5");
    public static readonly ApiSportsTeam TennesseeTitans = new("6");
    public static readonly ApiSportsTeam DetroitLions = new("7");
    public static readonly ApiSportsTeam AtlantaFalcons = new("8");
    public static readonly ApiSportsTeam ClevelandBrowns = new("9");
    public static readonly ApiSportsTeam CincinnatiBengals = new("10");
    public static readonly ApiSportsTeam ArizonaCardinals = new("11");
    public static readonly ApiSportsTeam PhiladelphiaEagles = new("12");
    public static readonly ApiSportsTeam NewYorkJets = new("13");
    public static readonly ApiSportsTeam SanFrancisco49ers = new("14");
    public static readonly ApiSportsTeam GreenBayPackers = new("15");
    public static readonly ApiSportsTeam ChicagoBears = new("16");
    public static readonly ApiSportsTeam KansasCityChiefs = new("17");
    public static readonly ApiSportsTeam WashingtonCommanders = new("18");
    public static readonly ApiSportsTeam CarolinaPanthers = new("19");
    public static readonly ApiSportsTeam BuffaloBills = new("20");
    public static readonly ApiSportsTeam IndianapolisColts = new("21");
    public static readonly ApiSportsTeam PittsburghSteelers = new("22");
    public static readonly ApiSportsTeam SeattleSeahawks = new("23");
    public static readonly ApiSportsTeam TampaBayBuccaneers = new("24");
    public static readonly ApiSportsTeam MiamiDolphins = new("25");
    public static readonly ApiSportsTeam HoustonTexans = new("26");
    public static readonly ApiSportsTeam NewOrleansSaints = new("27");
    public static readonly ApiSportsTeam DenverBroncos = new("28");
    public static readonly ApiSportsTeam DallasCowboys = new("29");
    public static readonly ApiSportsTeam LosAngelesChargers = new("30");
    public static readonly ApiSportsTeam LosAngelesRams = new("31");
    public static readonly ApiSportsTeam MinnesotaVikings = new("32");

}
