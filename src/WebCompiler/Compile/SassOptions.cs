using Newtonsoft.Json;

namespace WebCompiler
{
    /// <summary>
    /// Give all options for the Sass compiler
    /// </summary>
    public class SassOptions : BaseOptions<SassOptions>
    {
        private const string trueStr = "true";

        /// <summary> Creates a new instance of the class.</summary>
        public SassOptions()
        { 
        IncludePath = string.Empty;
        IndentType = "space";
        IndentWidth = 2;
        OutputStyle = "nested";
        Precision = 5;
        RelativeUrls = true;
        SourceMapRoot = string.Empty;
        }

        /// <summary>
        /// Loads the settings based on the config
        /// </summary>
        protected override void LoadSettings(Config config)
        {
            base.LoadSettings(config);

            if (config.Options.ContainsKey("outputStyle"))
                OutputStyle = config.Options["outputStyle"].ToString();

            if (config.Options.ContainsKey("indentType"))
                IndentType = config.Options["indentType"].ToString();

            int precision = 5;
            if (int.TryParse(GetValue(config, "precision"), out precision))
                Precision = precision;

            int indentWidth = -1;
            if (int.TryParse(GetValue(config, "indentWidth"), out indentWidth))
                IndentWidth = indentWidth;

            var relativeUrls = GetValue(config, "relativeUrls");
            if (relativeUrls != null)
                RelativeUrls = relativeUrls.ToLowerInvariant() == trueStr;

            var includePath = GetValue(config, "includePath");
            if (includePath != null)
                IncludePath = includePath;

            var sourceMapRoot = GetValue(config, "sourceMapRoot");
            if (sourceMapRoot != null)
                SourceMapRoot = sourceMapRoot;
        }

        /// <summary>
        /// The file name should match the compiler name
        /// </summary>
        protected override string CompilerFileName
        {
            get { return "sass"; }
        }

        /// <summary>
        /// Path to look for imported files
        /// </summary>
        [JsonProperty("includePath")]
        public string IncludePath { get; set; }

        /// <summary>
        /// Indent type for output CSS.
        /// </summary>
        [JsonProperty("indentType")]
        public string IndentType { get; set; }

        /// <summary>
        /// Number of spaces or tabs (maximum value: 10)
        /// </summary>
        [JsonProperty("indentWidth")]
        public int IndentWidth { get; set; }

        /// <summary>
        /// Type of output style
        /// </summary>
        [JsonProperty("outputStyle")]
        public string OutputStyle { get; set; }


        /// <summary>
        /// Precision
        /// </summary>
        public int Precision { get; set; }

        /// <summary>
        /// This option allows you to re-write URL's in imported files so that the URL is always
        /// relative to the base imported file.
        /// </summary>
        [JsonProperty("relativeUrls")]
        public bool RelativeUrls { get; set; }

        /// <summary>
        /// Base path, will be emitted in source-map as is
        /// </summary>
        [JsonProperty("sourceMapRoot")]
        public string SourceMapRoot { get; set; }
    }
}
