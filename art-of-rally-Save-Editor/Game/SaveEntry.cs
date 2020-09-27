using Newtonsoft.Json;

namespace art_of_rally_Save_Editor.Game
{
    public sealed class SaveEntry
    {
        [JsonProperty("key")]
        public string Key
        {
            get;
            set;
        }

        [JsonProperty("value")]
        public object Value
        {
            get;
            set;
        }

        public SaveEntry()
        {
            Key = "";
            Value = 0;
        }

        public SaveEntry(string key, object value)
        {
            Key = key;
            Value = value;
        }
    }
}
