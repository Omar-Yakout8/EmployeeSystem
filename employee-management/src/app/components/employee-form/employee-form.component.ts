import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { EmployeeService } from '../../services/employee.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-employee-form',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, RouterModule],
  templateUrl: './employee-form.component.html',
  styleUrl: './employee-form.component.css'
})
export class EmployeeFormComponent implements OnInit {
  form!: FormGroup;
  isEdit = false;
  id!: number;

  constructor(
    private fb: FormBuilder,
    private employeeService: EmployeeService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.form = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      position: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });

    this.id = Number(this.route.snapshot.paramMap.get('id'));
    if (this.id) {
      this.isEdit = true;
      this.loadEmployee();
    }
  }

  async loadEmployee() {
    const res = await this.employeeService.getById(this.id);
    this.form.patchValue(res.data);
  }

  async submit() {
    if (this.form.invalid) return;

    try {
      if (this.isEdit) {
        await this.employeeService.update(this.id, this.form.value);
        alert('Employee updated');
      } else {
        await this.employeeService.add(this.form.value);
        alert('Employee added');
      }
      this.router.navigate(['/']);
    } catch {
      alert('Operation failed');
    }
  }
}
