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

        public List<Member> GetMembers(IMemberSearchTerms searchTerms)
        {
            return _datacontext.GetMembers().Where( e => (e.FirstName.ToLower().Contains(searchTerms.FirstName.ToLower()) || string.IsNullOrWhiteSpace(e.FirstName)) 
                && (e.LastName.ToLower().Contains(searchTerms.LastName.ToLower())) || (string.IsNullOrWhiteSpace(searchTerms.LastName))
                && (e.ContactNumber == searchTerms.ContactNumber || string.IsNullOrWhiteSpace(searchTerms.ContactNumber))).ToList();
        }

        public Member GetMember(int memberId)
        {
            return _datacontext.GetMember(memberId);
        }

        public Member SaveMember(Member member)
        {
            return _datacontext.SaveMember(member);
        }
    }
}
