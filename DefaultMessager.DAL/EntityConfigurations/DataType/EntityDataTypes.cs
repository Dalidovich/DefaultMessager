namespace DefaultMessager.DAL.EntityConfigurations.DataType
{
    public static class EntityDataTypes
    {
        public const string Guid = "uuid";
        public const string Smallint = "smallint";
        public const string Text = "text";
        public const string Character_varying = "character varying";
        public const string Text_array = "text[]";
        public static string GetCharacterVaryingLens(short lens) => string.Concat("character varying(", lens, ")");
    }
}
