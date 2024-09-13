namespace Vidly.Api;

public static class ApiEndpoints
{
	public static class Genre
	{
		private const string Base = "/genres";
		
		public const string Create = Base;
		
		public const string GetAll = Base;
		
		private const string BaseWithId = $"{Base}/{{id}}";
		
		public const string Get = BaseWithId;
		
		public const string Update = BaseWithId;
		
		public const string Delete = BaseWithId;

	}
}