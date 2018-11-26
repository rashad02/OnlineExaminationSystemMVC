using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseContext;
using Models;

namespace Repository
{
    public class BatchRepository
    {
        OnlineExaminationSystem db=new OnlineExaminationSystem();

        public ICollection<Trainer> GetTrainer()
        {
            var data = db.Trainers;
            return data.ToList();
        }

        public ICollection<Course> GetCourse()
        {
            var data = db.Courses;
            return data.ToList();
        }
        public bool AddExam(Exams exam)
        {
            db.Examses.Add(exam);

            return db.SaveChanges() > 0;
        }
        public bool UpdateExam(Exams exam)
        {
            db.Examses.Attach(exam);
            db.Entry(exam).State = EntityState.Modified;


            return db.SaveChanges() > 0;
        }
        public List<Exams> GetLastAddedExamByBatch(int batchId)
        {
            var data = db.Examses.Where(e => e.BatchId == batchId);
            return data.ToList();
        }
        public ICollection<Organization> GetOrganization()
        {
            var data = db.Organizations;
            return data.ToList();
        }

        public bool SaveBatch(Batch batch)
        {
            db.Batches.Add(batch);
            return db.SaveChanges() > 0;
        }

        public Batch GetLastAddedBatch()
        {
            var batchId = db.Batches.Max(b => b.Id);
            var data = db.Batches.FirstOrDefault(c => c.Id == batchId);
            return data;
        }
        public ICollection<Organization> GetOrganizationsById(int id)
        {
            var organization = db.Organizations.Where(o => o.Id == id);
            return organization.ToList();
        }
        public Course GetCoursesById(int courseId)
        {
            var data = db.Courses.FirstOrDefault(c => c.Id == courseId);
            return data;
        }

        public bool UpdateTrainer(Trainer trainer)
        {
            db.Trainers.Attach(trainer);
            db.Entry(trainer).State = EntityState.Modified;


            return db.SaveChanges() > 0;
        }

        public ICollection<Exams> GetExamsByCourseId(int courseId)
        {
            var data = db.Examses.Where(e => e.CourseId == courseId);
            return data.ToList();
        }

        public Batch GetBatchById(int id)
        {
            var data = db.Batches.FirstOrDefault(b => b.Id == id);
            return data;
        }

        public bool UpdateBatch(Batch batch)
        {
            db.Batches.Attach(batch);
            db.Entry(batch).State=EntityState.Modified;

            return db.SaveChanges() > 0;
        }

        public List<Exams> GetExamById(int id)
        {
            return db.Examses.Where(e => e.Id == id).ToList();
        }

        public List<Student> GetStudents()
        {
            return db.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            var data = db.Students.FirstOrDefault(s => s.Id == id);
            return data;
        }
    }
}
