import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../../services/employee.service';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.css'
})
export class EmployeeListComponent implements OnInit {
  employees: any[] = [];

  constructor(private employeeService: EmployeeService) {}

  ngOnInit() {
    this.loadEmployees();
  }

  async loadEmployees() {
    try {
      const res = await this.employeeService.getAll();
      this.employees = res.data;
    } catch (err) {
      alert('Failed to load employees');
    }
  }

  async deleteEmployee(id: number) {
    if (!confirm('Are you sure?')) return;
    try {
      await this.employeeService.delete(id);
      this.loadEmployees();
      alert('Employee deleted');
    } catch {
      alert('Delete failed');
    }
  }
}