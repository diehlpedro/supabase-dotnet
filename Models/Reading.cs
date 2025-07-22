using System.Text.Json.Serialization;

public class Reading
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Id { get; set; }  // nullable int, ignored if null when serializing

    [JsonPropertyName("sensorid")]
    public string? SensorId { get; set; }

    [JsonPropertyName("value")]
    public double Value { get; set; }

    [JsonPropertyName("unit")]
    public string? Unit { get; set; }
}