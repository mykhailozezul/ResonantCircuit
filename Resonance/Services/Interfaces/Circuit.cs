namespace Resonance.Services.Interfaces
{
    public interface Circuit
    {      
        public string Output<T>(bool showHeaders, T circuitModule)
        {
            string result = "";
            var props = circuitModule.GetType().GetProperties();

            foreach (var prop in props)
            {
                if (showHeaders)
                {
                    result += prop.Name + ",";
                }
                else
                {
                    var value = prop.GetValue(circuitModule);
                    result += value.GetType().GetProperty("SIValue").GetValue(value) + ",";
                }
            }

            result += "\n";
            return result;
        }
    }
}
