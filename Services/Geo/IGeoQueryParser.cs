using System.Collections.Generic;

namespace tsears.Weather.Services.Geo
{
  public interface IGeoQueryParser {
    Dictionary<string, string> Parse(string query);
  }
}
