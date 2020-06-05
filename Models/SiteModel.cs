using System;

namespace Maintel.Icon.Portal.Sync.AutotaskAPI.Spec.Models
{
	
	/// <summary>
	/// The icon portal site object for an Autotask Site
	/// </summary>	
	public class Site {

		/// <summary>
		/// The unique identifier for the site
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// The unique identifier for the site
		/// </summary>
		public int ParentAccountId { get; set; }
		
		/// <summary>
		/// The name of the site
		/// </summary>
		public string AccountName { get; set; }
      
		/// <summary>
		/// The first address line of the site
		/// </summary>
		public string Address1 { get; set; }
      
		/// <summary>
		/// The second address line of the site
		/// </summary>
		public string Address2 { get; set; }
      
		/// <summary>
		/// The city where the site is located
		/// </summary>
		public string City { get; set; }
      
		/// <summary>
		/// The state or county where the site is located
		/// </summary>
		public string State { get; set; }
     
		/// <summary>
		/// The zip or postal code for the site
		/// </summary>
		public string Zipcode { get; set; }
      
		/// <summary>
		/// The country where the site is located
		/// </summary>
		public string Country { get; set; }
      
		/// <summary>
		/// The date and time that the site was created
		/// </summary>
		public DateTime DateCreated { get; set; }
      
		/// <summary>
		/// The external identifier for the site
		/// </summary>
		public string ExternalIdentifier { get; set; }
	}
}