namespace Vidly.Api;

public static class ApiEndpoints
{
	private const string ApiBase = "/api";	
	public static class Genre
	{
		private const string Base = $"{ApiBase}/genres";
		
		public const string Create = Base;
		
		public const string GetAll = Base;
		
		private const string BaseWithId = $"{Base}/{{id}}";
		
		public const string Get = BaseWithId;
		
		public const string Update = BaseWithId;
		
		public const string Delete = BaseWithId;

	}
	
	public static class Customer
	{
		private const string Base = $"{ApiBase}/customers";
		
		public const string Create = Base;
		
		public const string GetAll = Base;
		
		private const string BaseWithId = $"{Base}/{{id}}";
		
		public const string Get = BaseWithId;
		
		public const string Update = BaseWithId;
		
		public const string Delete = BaseWithId;

	}
}