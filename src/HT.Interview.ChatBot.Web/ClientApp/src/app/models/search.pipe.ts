import { Pipe, PipeTransform } from '@angular/core';
@Pipe({
  name: 'searchFilter'
})
export class SearchPipe implements PipeTransform {

   getRole(roleId: number)
   {
       switch(roleId)
       {
           case 1: return "Admin";
           case 2: return "Human Resource";
           case 3: return "Candidate";
           case 4: return "Panelist";
       }
   }

  transform(value: any, args?: any): any {    
    if (!args) {
      return value;
    }
    return value.filter((val) => {      
      let rVal = (val.email.toLocaleLowerCase().includes(args)) || (val.name.toLocaleLowerCase().includes(args) || this.getRole(val.roleId).toLocaleLowerCase().includes(args));
      return rVal;
    })

  } 

}