namespace ClassLibrary;

public class CityService
{
    private List<String> _cityList = [];

    public List<String> GetCityList() {
        return _cityList;
    }

    public CityService()
    {
        _cityList = [
            "AAA",
            "BBB",
            "CCC",
            "DDD",
            "EEE"
            ];
    }

}

public interface ICityService { 
    
}
