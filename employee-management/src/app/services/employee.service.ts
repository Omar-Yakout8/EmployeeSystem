import { Injectable } from '@angular/core';
import axios from 'axios';


const API_URL='https://localhost:7148/api/Employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  async getAll() {
    return axios.get(API_URL);
  }

  async getById(id: number) {
    return axios.get(`${API_URL}/${id}`);
  }

  async add(employee: any) {
    return axios.post(API_URL, employee);
  }

  async update(id: number, employee: any) {
    return axios.put(`${API_URL}/${id}`, employee);
  }

  async delete(id: number) {
    return axios.delete(`${API_URL}/${id}`);
  }
}
