using Liberty.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Repository.Interface
{
    public interface IMemberRepository
    {

        List<Member> GetMembers(IMemberSearchTerms parameters);

        Member SaveMember(Member member);

        Member GetMember(int id);
    }
}
