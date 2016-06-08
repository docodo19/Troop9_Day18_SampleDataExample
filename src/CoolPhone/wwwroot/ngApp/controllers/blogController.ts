namespace CoolPhone.Controllers {

    // -- BlogsController --
    export class BlogsController {
        public blogs;

        constructor(private blogService:CoolPhone.Services.BlogService) {
            this.getBlogs();  // get blogs as soon as page loads
        }

        getBlogs() {
            this.blogs = this.blogService.getBlogs();
        }
    }

    // -- BlogsDetailController --
    export class BlogsDetailController {
        public blog;
        public comment; // will contain the comment that will be saved
        private blogId;

        constructor(
            private blogService: CoolPhone.Services.BlogService,
            $stateParams: angular.ui.IStateParamsService) {

            // capture the id of the blog from the router parameter and assign it to this.blogId using $stateParams
            this.blogId = $stateParams['id'];
            // run the getBlog method to get a single blog as soon as page loads
            this.getBlog();
        }

        getBlog() {
            this.blog = this.blogService.getBlog(this.blogId);
        }

        saveComment() {
            this.blogService.saveBlogComment(this.blogId, this.comment).then(() => {
                this.getBlog();
                let el: any = document.getElementById("commentForm");
                el.reset();
            });
        }
    }

    // -- BlogsEditController --
    export class BlogsEditController {
        public blog;
        private blogId;

        constructor(
            private blogService: CoolPhone.Services.BlogService,
            $stateParams: angular.ui.IStateParamsService,
            private $state: angular.ui.IStateService) {

            this.blogId = $stateParams['id'];
            this.blog = this.blogService.getBlog(this.blogId);
        }

        saveBlog() {
            this.blogService.saveBlog(this.blog).then(() => {
                this.$state.go('blogs');
            });
        }
    }
}