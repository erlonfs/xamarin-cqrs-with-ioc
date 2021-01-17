namespace Poc.MobileApp.Domain.Queries
{
	public class PaginacaoInfo
	{
		public static PaginacaoInfo Padrao { get; set; } = new PaginacaoInfo();

		public int PageSize { get; set; } = 36;
		public int PageNumber { get; set; } = 1;
		public string OrderBy { get; set; }
	}

}
