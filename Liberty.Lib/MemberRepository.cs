using Liberty.Data;
using Liberty.Data.Interfaces;
using Liberty.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Lib
{
    public class MemberRepository : IMemberRepository
    {
        private IDataContext _datacontext;

        public MemberRepository(IDataContext dataContext)
        {
            _datacontext = dataContext;
        }


        /// <summary>
        /// find members based on the search terms, or return all members
        /// </summary>
        /// <param name="searchTerms">the search terms to execute</param>
        /// <returns></returns>
        public List<Member> GetMembers(IMemberSearchTerms searchTerms)
        {
            return _datacontext.GetMembers().Where( e => (e.FirstName.ToLower().Contains(searchTerms.FirstName.ToLower()) || e.FirstName == "") 
                                                      && (e.LastName.ToLower().Contains(searchTerms.LastName.ToLower()) || searchTerms.LastName == "")
                                                      && (e.ContactNumber == searchTerms.ContactNumber || searchTerms.ContactNumber == "")).ToList();
        }


        /// <summary>
        /// return a single member 
        /// </summary>
        /// <param name="memberId">the database id of the member</param>
        /// <returns>a Member</returns>
        public Member GetMember(int memberId)
        {
            return _datacontext.GetMember(memberId);
        }


        /// <summary>
        /// save the member
        /// </summary>
        /// <param name="member">the member to be saved</param>
        /// <returns></returns>
        public Member SaveMember(Member member)
        {
            return _datacontext.SaveMember(member);
        }
    }
}
