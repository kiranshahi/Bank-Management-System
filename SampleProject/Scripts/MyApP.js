var app = angular.module('myAppS', ['ngRoute', 'angularUtils.directives.dirPagination', 'ngStorage']);

app.filter("mydate", function () {
    var re = /\/Date\(([0-9]*)\)\//;
    return function (x) {
        var m = x.match(re);
        if (m) return new Date(parseInt(m[1]));
        else return null;
    };
});

//app.directive("fileread", [function () {
//    return {
//        scope: {
//            fileread: "="
//        },
//        link: function (scope, element, attributes) {
//            element.bind("change", function (changeEvent) {
//                scope.$apply(function () {
//                    scope.fileread = changeEvent.target.files[0];
//                    // or all selected files:
//                    // scope.fileread = changeEvent.target.files;
//                });
//            });
//        }
//    }
//}]);

app.factory('crudServiceUser', function ($http) {
    crudUserObj = {};
    crudUserObj.GetAll = function () {
        var Emps;
        Emps = $http(
            {
                method: 'Get',
                url: '/Security/Login/getUser'
            }
            ).then(function (response) {
                return response.data;
            });
        return Emps;
    }

    crudUserObj.GetByEid = function (eid) {
        var Emp;
        Emp = $http(
            {
                method: 'Get',
                url: '/Employee/BankAccount/getById',
                params: { id: eid }
            }
            ).then(function (response) {
                return response.data;
            });
        return Emp;
    }

    crudUserObj.GetByEidForChq = function (eid) {
        var Emp;
        Emp = $http(
            {
                method: 'Get',
                url: '/Employee/ChequeIssue/getBychqIdForCheque',
                params: { custname: eid }
            }
            ).then(function (response) {
                return response.data;
            });
        return Emp;
    }

    crudUserObj.GetActType = function () {
        var Emp;
        Emp = $http(
            {
                method: 'Get',
                url: '/Employee/BankAccount/getActType'
            }
            ).then(function (response) {
                return response.data;
            });
        return Emp;
    }

    crudUserObj.DeleteById = function (use) {
        var Emp;
        Emp = $http({
            method: 'Post',
            url: '/Admin/User/Delete',
            data: use
        }
        ).then(function (response) {
            return response.data;
        });
        return Emp;
    }

    crudUserObj.Create = function (openact) {
        var Emp;
        Emp = $http({
            method: 'Post',
            url: '/Employee/BankAccount/Index',
            data: openact
        }
        ).then(function (response) {
            return response.data;
        });
        return Emp;
    }


    crudUserObj.Update = function (use) {
        var Emp;
        Emp = $http({
            method: 'Post',
            url: '/Admin/User/edit',
            data: use
        }
        ).then(function (response) {
            return response.data;
        });
        return Emp;
    }

    crudUserObj.getActNo = function () {
        var Emp;
        Emp = $http({
            method: 'Post',
            url: '/Employee/BankAccount/getActNumber'
        }
        ).then(function (response) {
            return response.data;
        });
        return Emp;
    }

    crudUserObj.getChqStartNo = function (cheques) {
        var Emp;
        Emp = $http({
            method: 'Post',
            url: '/Employee/ChequeIssue/getchqStartNum',
            data: cheques
        }
        ).then(function (response) {
            return response.data;
        });
        return Emp;
    }

    crudUserObj.GetChqStatus = function (chequeno) {
        var Emp;
        Emp = $http({
            method: 'Get',
            url: '/Employee/BankAccount/getchqStatus',
            params: { chqno: chequeno }
        }
        ).then(function (response) {
            return response.data;
        });
        return Emp;
    }


    return crudUserObj;
});

app.factory('loanFactory', function ($http) {
    loanObj = {};

    loanObj.GetAll = function()
    {
        var loan;
        loan = $http({
            method: 'Get',
            url: '/Admin/Loan/ViewLoanType'
        }).then(function (response) {
            return response.data;
        });
        return loan;
    }

    loanObj.GetLoanType = function () {
        var loan;
        loan = $http({
            method: 'Get',
            url: '/Admin/Loan/loadLoanType'
        }).then(function (response) {
            return response.data;
        });
        return loan;
    }

    loanObj.GetInterestRateById = function (id) {
        var loan;
        loan = $http({
            method: 'Get',
            url: '/Admin/Loan/loadInterestRateByLoanType',
            params: { Id : id }
        }).then(function (response) {
            return response.data;
        });
        return loan;
    }

    

    return loanObj;
});

//app.controller("myCntrl-1", function ($cookies, $scope) {
//app.controller("myCntrl-1", function ($sessionStorage, $scope) {
app.controller("myCntrl-1", function ($localStorage, $scope) {
    $scope.gtr = "Hello";
    $scope.PutVal = function (em) {
        //$cookies.put("MyVal", "MTT");
        // $sessionStorage.MyVal = "MTT";
        $localStorage.MyVal = em;
    };
});

//app.controller("myCntrl-2", function ($cookies, $scope) {
//app.controller("myCntrl-2", function ($sessionStorage, $scope) {
app.controller("myCntrl-2", function ($localStorage, $scope) {
    $scope.sub = "Submit";
    $scope.ReadVal = function () {
        // $scope.ValueRead = $cookies.get("MyVal");
        //$scope.ValueRead = $sessionStorage.MyVal;

       
        $scope.ValueRead = $localStorage.MyVal;


    };
});

//app.controller("myCntrl-3", function ($cookies, $scope) {
//app.controller("myCntrl-3", function ($sessionStorage, $scope) {
app.controller("myCntrl-3", function ($localStorage, $scope) {
    $scope.RemoveVal = function () {
        //$cookies.remove("MyVal");
        //delete $sessionStorage.MyVal;
        delete $localStorage.MyVal;
    };
});


app.controller('usersController', function ($scope, crudServiceUser, $filter, loanFactory) {

    $scope.acctNum = "101-";

    $scope.today = new Date();
    $scope.act = "Javas";

    $scope.curBal = function () {
        $scope.totalBalance = $scope.Emp.depoAmt - (-$scope.Emp.currentBalance);
    }

    $scope.opnBaL = function (optBal) {
        $scope.getopnBal = optBal;
    }

  

    $scope.GetAll = function () {
        crudServiceUser.GetAll().then(function (result) {
            $scope.Emp = result;
        })
    }

    $scope.GetAllLoanType = function () {
        loanFactory.GetAll().then(function (result) {
            $scope.loanData = result;
        })
    }

    $scope.GetInterestAmount = function () {

        $scope.loanTotalInterest = (($scope.loanAmt * $scope.loanInterestData.Interest_Rate * $scope.loanPeriod) / 100) - (-$scope.loanAmt);
        $scope.loanAnnualInterest = $scope.loanTotalInterest / $scope.loanPeriod;
        $scope.MonthlyInterest = ($scope.loanAnnualInterest) / 12;
    }

   

    $scope.GetInterestRateById = function (id) {
        loanFactory.GetInterestRateById(id).then(function (result) {
            $scope.loanInterestData = result;
           

            loanFactory.GetAll().then(function (result) {
                $scope.loanData = result;
            })

        })

    }

    $scope.GetChqStartNo = function (Cheque) {
        crudServiceUser.getChqStartNo(Cheque).then(function (result) {
            $scope.Chqs = result;
        })
    }

    $scope.GetActNo = function () {
        crudServiceUser.getActNo().then(function (result) {
            $scope.Emp = result;
        })
    }

    $scope.NoLeavesChange = function (NoLeaves) {
        $scope.ChqEndNo = $scope.Chqs.chqStartNo - (-$scope.NoLeaves) - 1;
    }

    

    $scope.getbyeid = function (eid) {
        crudServiceUser.GetByEid(eid).then(function (result) {
            $scope.Emp = result;
        })
    }

    $scope.getbyeidforchq = function (CustName) {
       
            crudServiceUser.GetByEidForChq(CustName).then(function (result) {
                $scope.Cheque = result;
            })
       
    }


    $scope.ChqStatus = function(chqno)
    {
        crudServiceUser.GetChqStatus(chqno).then(function (result) {
            $scope.Cheque = result;
            if (($scope.Cheque[0].status == "cancelled")) {
                alert('Entered Cheque Number Is Cancelled');
                $scope.Emp.chqNo = "";
            }
            if (($scope.Cheque[0].status == "Used")) {
                alert('Entered Cheque Number Is Already Used');
                $scope.Emp.chqNo = "";
            } 

        });

    }
        
    $scope.checkDate = function (checkDate)
    {

        $scope.date = new Date();
        $scope.date = $filter('date')($scope.date, 'dd-MM-yyyy');
        $scope.checkdate = checkDate;
        $scope.checkdate = $filter('date')($scope.checkdate, 'dd-MM-yyyy');        
        if ($scope.checkdate < $scope.date) {
            alert("Cheque Date Not Reached");
            $scope.Emp.chqdate = "";
            } 
    }

    $scope.checkBal = function(amount)
    {
        if (amount > $scope.Emp.currentBalance) {
            alert("Insufficient Balance");
            $scope.withamt = " ";
        }

        else {
            $scope.totalBalance = $scope.Emp.currentBalance - amount;
        }

    }


    $scope.DeleteByEid = function (eid) {
        crudServiceUser.DeleteById(eid).then(function (result) {
            //$scope.Msg = result.EName + "Has Been Deleted Successfully";
            $scope.Msg = alert(result.EName + " " + "Has Been Deleted Successfully");
            crudServiceUser.GetAll().then(function (result) {
                $scope.Emps = result;
            })
        })
    }

    $scope.CreateOpen = function (openact) {
        crudServiceUser.Create(openact).then(function (result) {
            //$scope.Msg = result.EName + " Has Been Deleted Successfully";
            $scope.Msg = alert(result.custname + " Has Been Created Successfully");
            //crudServiceUser.GetAll().then(function (result) {
            //    $scope.Emps = result;
            //})
        })
    }

    $scope.UpdateUser = function (Emp) {
        crudServiceUser.Update(Emp).then(function (result) {
            //$scope.Msg = result.EName + " Has Been Deleted Successfully";
            $scope.Msg = alert(result.EName + " Has Been Updated Successfully");
            crudServiceUser.GetAll().then(function (result) {
                $scope.Emps = result;
            })
        })
    }

});



app.config(function ($routeProvider) {

    $routeProvider.when('/ListUser', {
        templateUrl: '/Admin/User/ListUserView',
        controller: 'userController'
    });

    $routeProvider.when('/DeleteView', {
        templateUrl: '/Admin/User/deleteView',
        controller: 'deleteController'
    });

    $routeProvider.when('/Details', {
        templateUrl: '/Admin/User/Details',
        controller: 'detailsController'
    });

    $routeProvider.when('/EditView', {
        templateUrl: '/Admin/User/editView',
        controller: 'editController'
    });

    $routeProvider.when('/Loan', {
        templateUrl: '/Admin/Loan/Index',
        controller: 'loanController'
    });

    $routeProvider.when('/AuthorizeDeposit', {
        templateUrl: '/Admin/AuthorizeDeposit/Index',
        controller: 'authorizedepositController'
    });

    $routeProvider.when('/VerifyAccount', {
        templateUrl: '/Admin/VerifyAccount/Index',
        controller: 'verifyaccountController'
    });

    $routeProvider.when('/ChequeCancellation', {
        templateUrl: '/Admin/ChequeCancellation/Index',
        controller: 'chequecancellationController'
    });

    $routeProvider.when('/Home', {
        templateUrl: '/Common/Home/Index',
        controller: 'homeController'
    });

    $routeProvider.when('/Register', {
        templateUrl: '/Security/Login/Register',
        controller: 'registerController'
    });

    $routeProvider.when('/OpenNewAccount', {
        templateUrl: '/Employee/BankAccount/Index',
        controller: 'OpenNewAccountController'
    });

    $routeProvider.when('/Deposit', {
        templateUrl: '/Employee/BankAccount/Deposit',
        controller: 'DepositController'
    });

    $routeProvider.when('/Withdrawal', {
        templateUrl: '/Employee/BankAccount/Withdrawal',
        controller: 'WithdrawalController'
    });

    $routeProvider.when('/IssueCheques', {
        templateUrl: '/Employee/IssueCheques/Index',
        controller: 'IssueChequesController'
    });

   
    $routeProvider.when('/Login', {
        templateUrl: '/Security/Login/Login',
        controller: 'LoginController'
    });

    $routeProvider.when('/ManageRoles', {
        templateUrl: '/Security/Login/Roles',
        controller: 'ManageRolesController'
    });

    $routeProvider.otherwise({
        redirectTo: '/'
    });

});