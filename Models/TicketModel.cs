using System;

namespace Maintel.Icon.Portal.Sync.AutotaskAPI.Spec.Models
{
	
    /// <summary>
    /// The icon portal site object for an Autotask ticket
    /// </summary>	
    public class Ticket {

		/// <summary>
		/// The unique identifier for the ticket
		/// </summary>
		public int Id { get; set; }

        /// <summary>
        /// The unique identifier for the ticket type
        /// </summary>
        public int TicketTypeId { get; set; }

        /// <summary>
        /// The account identifier associated with the ticket
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// The date and time of the last ticket activity
        /// </summary>
        public DateTime? LastActivityDateTime { get; set; }

        /// <summary>
        /// The unique identifier for the ticket status
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// The date and time the ticket was created
        /// </summary>
        public DateTime CreateDateTime { get; set; }

        /// <summary>
        /// The title (or subject) of the ticket
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The ticket description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The unique identifier for the ticket priority
        /// </summary>
        public int PriorityId { get; set; }

        /// <summary>
        /// The date and time the ticket is due
        /// </summary>
        public DateTime? DueDateTime { get; set; }

        /// <summary>
        /// The date and time the ticket was completed
        /// </summary>
        public DateTime? CompleteDateTime { get; set; }
    }
}