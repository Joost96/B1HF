using HaarlemFestival.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        DBHF db;

        public QuestionRepository(DBHF db)
        {
            this.db = db;
        }

        public void CreateQuestion(Question question)
        {
            db.Questions.Add(question);
            
            db.SaveChanges();
        }

    }
}