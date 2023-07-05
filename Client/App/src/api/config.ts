export let BASECONFIG = {
  apiUrl: {
    url: 'https://localhost:44336/api/'
  },
  //reportsPageUrl: {
  //    url: 'http://localhost:62070/ReportsControl/Reports.aspx'
  //    //url: 'http://' + window.location.hostname + '/ISMWEBAPI/ReportsControl/Reports.aspx'        
  //},

  //Zadnja izvršena
  //npm run
  //ng b --prod --aot=false --build-optimizer=false
  //ng b --prod --aot=false --named-chunks  --build-optimizer=false
  
};
export let CONFIG = {
  baseUrls: {
    login: BASECONFIG.apiUrl.url + 'Login/Login/',
    udruzenje: {
      save: BASECONFIG.apiUrl.url + 'Udruzenje/Save/',
      getById: BASECONFIG.apiUrl.url + 'Udruzenje/GetById/'
    },
    korisnik: {
      add: BASECONFIG.apiUrl.url + 'Korisnik/Add/',
    },
    dokument: {
      save: BASECONFIG.apiUrl.url + 'Dokument/Save/',
      getById: BASECONFIG.apiUrl.url + 'Dokument/GetById/',
      download: BASECONFIG.apiUrl.url + 'Dokument/Download/'
    },
    shared: {
      getAdministrativneJediniceForDropdown: BASECONFIG.apiUrl.url + 'AdministrativnaJedinica/ForDropdown/',
      getUdruzenjaForDropdown: BASECONFIG.apiUrl.url + 'Udruzenje/ForDropdown/',
    },
  },
  enums: {
    ulogaKorisnikaEnum: {
      superAdministrator: 1,
      administratorUdruzenja: 2,
      korisnik: 3
    },
    udruzenjaEnum: {
      SRSBiH: 2
    }
  }
}
