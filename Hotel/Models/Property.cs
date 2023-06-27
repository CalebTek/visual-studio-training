namespace Hotel.Models
{
	public class Property
	{
		public Property(string id,string? picname, string? city, string? location, string? price, string? type, string? popularity)
		{
			Id = id;
			PicName = picname;
			Name = city;
			Location = location;
			Price = price;
			Type = type;
			Popularity = popularity;
		}

		public string Id { get; set; }
		public string? PicName { get; set; }
		public string? Name { get; set; }
		public string? Location { get; set; }
		public string? Price { get; set; }
		public string? Type { get; set; }
		public string? Popularity { get; set; }
		 

	}
}
