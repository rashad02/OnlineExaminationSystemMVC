using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository;
namespace BLL
{
    public class BatchManager
    {
        BatchRepository batchRepository=new BatchRepository();

        public ICollection<Trainer> GetTrainer()
        {
                return batchRepository.GetTrainer();
        }

        public ICollection<Course> GetCourse()
        {
            return batchRepository.GetCourse();
        }

        public ICollection<Organization> GetOrganization()
        {
            return batchRepository.GetOrganization();
        }

        public bool SaveBatch(Batch batch)
        {
                return batchRepository.SaveBatch(batch);
        }

        public Batch GetLastAddedBatch()
        {
                return batchRepository.GetLastAddedBatch();
        }
        public ICollection<Organization> GetOrganizationsById(int id)
        {
            return batchRepository.GetOrganizationsById(id);
        }
        public Course GetCoursesById(int courseId)
        {
            return batchRepository.GetCoursesById(courseId);
        }

        public bool UpdateTrainer(Trainer trainer)
        {
            return batchRepository.UpdateTrainer(trainer);
        }

        //public Batch GetLastAddedBatch()
        //{
        //    return batchRepository.GetLastAddedBatch();
        //}
        public bool AddExam(Exams exam)
        {
                return batchRepository.AddExam(exam);
        }

        public List<Exams> GetLastAddedExamByBatch(int batchId)
        {
            return batchRepository.GetLastAddedExamByBatch(batchId);
        }

        public bool UpdateExam(Exams exam)
        {
            return batchRepository.UpdateExam(exam);
        }

        public ICollection<Exams> GetExamsByCourseId(int courseId)
        {
                return batchRepository.GetExamsByCourseId(courseId);
        }

        public Batch GetBatchById(int id)
        {
                return batchRepository.GetBatchById(id);
        }

        public bool UpdateBatch(Batch batch)
        {
                return batchRepository.UpdateBatch(batch);
        }

        public List<Exams> GetExamById(int id)
        {
                return batchRepository.GetExamById(id);
        }

        public List<Student> GetStudents()
        {
                return batchRepository.GetStudents();
        }

        public Student GetStudentById(int id)
        {
                return batchRepository.GetStudentById(id);
        }

      
    }
}
