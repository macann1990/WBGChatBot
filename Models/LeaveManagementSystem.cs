using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerServiceChatBot.Models
{
    [Serializable]
    public class LeaveManagementSystem
    {
        public enum LeaveType
        {
            Causual = 1,
            Sick = 2,
            Annual = 3,
            Floating = 4,
            Compensation =5,
            Other =6            
        }
        public List<LeaveType> typeOfLeave;
        [Prompt("Enter The Reason for the Leave")]
        public string Reason;
        [Prompt("What is Your First Name")]
        public string FirstName;
        [Describe("Surname")]
        public string LastName;
        [Prompt("Enter the Date for the leave you want to apply")]
        public DateTime? Period;
        public static IForm<LeaveManagementSystem> BuildForm()
        {
            return new FormBuilder<LeaveManagementSystem>().Message("Welcome to LMS").Build();
        }
    }
}