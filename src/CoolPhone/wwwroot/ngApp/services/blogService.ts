namespace CoolPhone.Services {

    export class BlogService {
        public blogResource;
        public blogCommentResource;

        constructor($resource:angular.resource.IResourceService) {
            this.blogResource = $resource('api/blog/:id');
            this.blogCommentResource = $resource('api/blogComment/:id');
        }

        // get a list of blogs
        getBlogs() {
            return this.blogResource.query();
        }

        // get a single blog with comments associated with it
        getBlog(blogId) {
            return this.blogResource.get({ id: blogId });
        }

        // Create or Edit blog
        saveBlog(blog) {
            return this.blogResource.save(blog).$promise;
        }

        // save a single blog comment
        saveBlogComment(blogId, comment) {
            return this.blogCommentResource.save({ id: blogId }, comment).$promise;
        }
    }
    angular.module('CoolPhone').service('blogService', BlogService);
}