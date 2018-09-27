export class User {
  id: Number
  sessionId : string
  roleId: Number
  email: string
  firstName: string
  lastName: string
  genderId: Number
  mobile: Number
  jobProfileId?: Number
  interviewDate: Date
  remark: string
  endResult: string
  socialAccountInfo: string
  photoUrl: string
  provider: string
  claims: any
  isActive: boolean
  createdBy: string
}
