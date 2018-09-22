// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  production: false,
  dialogflow: {
    interviewAgent: 'f32467d4e47245c794456f5bd1cf8e0a',
    webAPIUrl: 'http://localhost:50463/api/v1/',
    get: '/get?',
    getMany: '/get-many',
    interviewController: 'interview'
  },
  action: {
    get: '/get',
    getWithParameters: '/get?',
    getMany: '/get-many',
    getManyWithParameters: '/get-many?',
  },
  controller: {
    userController: 'user'
  },
  application: {
    pageSize: 10
  }
};
