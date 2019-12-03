using SocGauShop.Data.Infrastructure;
using SocGauShop.Data.Repositories;
using SocGauShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocGauShop.Service
{
    public interface IPostService
    {
        Post Add(Post post);
        void Update(Post post);
        Post Delete(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow);

        Post GetById(int id);
        IEnumerable<Post> GetAllByTagPage(string tag, int page, int pageSize, out int totalRow);
        void SaveChanges();
    }
    public class PostService : IPostService
    {
        IPostRepository _postRepository;
        IUnitOfWork _unitOfWork;
        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }
        public Post Add(Post post)
        {
            return this._postRepository.Add(post);
        }

        public Post Delete(int id)
        {
            return this._postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return this._postRepository.GetAll(new string[] { "PostCategory"});
        }

        public IEnumerable<Post> GetAllByTagPage(string tag, int page, int pageSize, out int totalRow)
        {
            //TODO Select all post by tag
            return this._postRepository.GetAllByTag(tag, page, pageSize, out totalRow);
        }

        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return this._postRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public Post GetById(int id)
        {
            return this._postRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            this._unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            this._postRepository.Update(post);
        }
    }
}
