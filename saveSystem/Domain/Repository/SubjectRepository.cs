using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saveSystem.Domain.Repository
{
    public class SubjectRepository
    {
        private readonly AppDbContext context;
        public SubjectRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Subject> GetSubjects()
        {
            return context.Subjects.OrderBy(x => x.SubjectName);
        }

        public Subject GetSubjectById(int id)
        {
            return context.Subjects.Single(x => x.Id == id);
        }

        public void SaveSubject(Subject entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }

        public void DeleteSubject(int id)
        {
            var entity = context.Subjects.First(x => x.Id == id);
            context.Subjects.Remove(entity);
            context.SaveChanges();
        }


    }
}
