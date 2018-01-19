using HaarlemFestival.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaarlemFestival.Repositories
{
    interface IQuestionRepository
    {
        void CreateQuestion(Question question);
    }
}
