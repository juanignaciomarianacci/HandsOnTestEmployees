import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'employee',
    templateUrl: './employee.component.html'
})
export class EmployeeDataComponent {
    public employees: Employee[];
    private baseUrl: string;
    public employeesLoading: boolean;
    public employeeNotFound: boolean;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
        this.employeesLoading = true;

        http.get(this.baseUrl + 'api/Employee').subscribe(result => {
            this.employees = result.json() as Employee[];
            this.employeesLoading = false;
        }, error => console.error(error));
    }

    getEmployees(id: any) {
        this.employees = [];
        this.employeesLoading = true;
        this.employeeNotFound = false;

        if (id) {
            this.http.get(this.baseUrl + 'api/Employee/' + id).subscribe(result => {
                this.employees.push(result.json() as Employee);
                this.employeesLoading = false;
            }, error => this.showErrorMessage(error));
        }
        else {
            this.http.get(this.baseUrl + 'api/Employee').subscribe(result => {
                this.employees = result.json() as Employee[];
                this.employeesLoading = false;
            }, error => console.error(error));
        }


    }

    showErrorMessage(error: any) {
        this.employeesLoading = false;

        if (error.status == 404)
            this.employeeNotFound = true;

        console.error(error);
    }
}

export class Employee {
    id: number;
    name: string;
    contractTypeName: string;
    roleId: number;
    roleName: string;
    roleDescription: string;
    annualSalary: number;
}