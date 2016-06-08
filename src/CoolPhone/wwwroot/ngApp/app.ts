namespace CoolPhone {

    angular.module('CoolPhone', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: CoolPhone.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: CoolPhone.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('blogs', {
                url: '/blogs',
                templateUrl: '/ngApp/views/blogs.html',
                controller: CoolPhone.Controllers.BlogsController,
                controllerAs: 'controller'
            })
            .state('blogsDetail', {
                url: '/blogs/detail/:id',
                templateUrl: '/ngApp/views/blogsDetail.html',
                controller: CoolPhone.Controllers.BlogsDetailController,
                controllerAs: 'controller'
            })
            .state('blogsEdit', {
                url: '/blogs/edit/:id',
                templateUrl: '/ngApp/views/blogsEdit.html',
                controller: CoolPhone.Controllers.BlogsEditController,
                controllerAs: 'controller'
            })
            //.state('blogsDelete', {
            //    url: '/blogs/delete/:id',
            //    templateUrl: '/ngApp/views/blogsDelete.html',
            //    controller: CoolPhone.Controllers.BlogsDeleteController,
            //    controllerAs: 'controller'
            //})
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    

}
