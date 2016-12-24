app.run(run).config(config);

function run($rootScope, $window, $state, authService) {

    $rootScope.$on("$stateChangeStart", function (event, toState) {
        authService.fillAuthData();
        if (toState.name == "admin") {
            var isAdmin = false;
            angular.forEach(authService.authentication.roles, function (role) {
                if (role == "Admin")
                    isAdmin = true;
            });
            if (!isAdmin) {
                event.preventDefault();
                $state.go("profile", { profileId: authService.authentication.id });
            }
        }
        if (toState.external) {
            event.preventDefault();
            $window.open(toState.url, "_self");
        }
    });

    $rootScope.$on("$stateChangeSuccess", function (event, toState) {
        if (toState.external) {
            event.preventDefault();
            $window.open(toState.url, "_self");
        }
    });

    $rootScope.$on("$stateChangeError", function () {
    });

    authService.fillAuthData();
}

function config($provide, $mdThemingProvider) {
    $provide.decorator("$locale", function ($delegate) {
        return $delegate;
    });

    $mdThemingProvider.definePalette('ecoZonePalette', {
        '50': 'FAFAFA',
        '100': 'F5F5F5',
        '200': 'EEEEEE',
        '300': 'E0E0E0',
        '400': 'BDBDBD',
        '500': '9E9E9E',
        '600': '757575',
        '700': '616161',
        '800': '424242',
        '900': '000000',
        'A100': '000000',
        'A200': '000000',
        'A400': '000000',
        'A700': '000000',
        'contrastDefaultColor': '000000',

        'contrastDarkColors': ['50', '100', '200', '300', '400'],
        'contrastLightColors': 'FFFFFF'
    });

    $mdThemingProvider.theme("default")
        .primaryPalette("ecoZonePalette", {
            'default': "900",
            'hue-1': "100",
            'hue-2': "600"
        })
        .warnPalette("red");
}