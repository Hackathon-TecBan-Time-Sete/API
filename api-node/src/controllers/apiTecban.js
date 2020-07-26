const req = require('request-promise')
const fs = require('fs')

const key = fs.readFileSync(process.cwd() + '/src/certs/banco_1/client_private_key.key')
const cert = fs.readFileSync(process.cwd() + '/src/certs/banco_1/client_certificate.crt')

const key2 = fs.readFileSync(process.cwd() + '/src/certs/banco_2/client_private_key.key')
const cert2 = fs.readFileSync(process.cwd() + '/src/certs/banco_2/client_certificate.crt')

module.exports = {
  async account (request, response) {
    const res = await req.get({
      uri: 'https://rs1.tecban-sandbox.o3bank.co.uk/open-banking/v3.1/aisp/accounts',
      key: key,
      cert: cert,
      headers: {
        'Content-Type': 'application/json',
        'x-fapi-financial-id': 'c3c937c4-ab71-427f-9b59-4099b7c680ab',
        'x-fapi-interaction-id': '96531a29-ec8c-4f4c-9c16-0fd7cc3d4c62',
        Authorization: 'Bearer 2b03223b-ec05-435d-b12f-e70827644308'
      },
      rejectUnauthorized: false,
      form: {
        grant_type: 'client_credentials',
        scope: 'accounts openid'
      }
    })
    const res2 = await req.get({
      uri: 'https://rs2.tecban-sandbox.o3bank.co.uk/open-banking/v3.1/aisp/accounts',
      key: key2,
      cert: cert2,
      headers: {
        'Content-Type': 'application/json',
        'x-fapi-financial-id': 'c3c937c4-ab71-427f-9b59-4099b7c680ab',
        'x-fapi-interaction-id': '96531a29-ec8c-4f4c-9c16-0fd7cc3d4c62',
        Authorization: 'Bearer b6311938-db3d-45e3-a92e-6b8049909285'
      },
      rejectUnauthorized: false,
      form: {
        grant_type: 'client_credentials',
        scope: 'accounts openid'
      }
    })
    return response.json([JSON.parse(res), JSON.parse(res2)])
  },

  async products (request, response) {
    const res = await req.get({
      uri: 'https://rs1.tecban-sandbox.o3bank.co.uk/open-banking/v3.1/aisp/products',
      key: key,
      cert: cert,
      headers: {
        'Content-Type': 'application/json',
        'x-fapi-financial-id': 'c3c937c4-ab71-427f-9b59-4099b7c680ab',
        'x-fapi-interaction-id': '96531a29-ec8c-4f4c-9c16-0fd7cc3d4c62',
        Authorization: 'Bearer 2b03223b-ec05-435d-b12f-e70827644308'
      },
      rejectUnauthorized: false,
      form: {
        grant_type: 'client_credentials',
        scope: 'accounts openid'
      }
    })
    const res2 = await req.get({
      uri: 'https://rs2.tecban-sandbox.o3bank.co.uk/open-banking/v3.1/aisp/products',
      key: key2,
      cert: cert2,
      headers: {
        'Content-Type': 'application/json',
        'x-fapi-financial-id': 'c3c937c4-ab71-427f-9b59-4099b7c680ab',
        'x-fapi-interaction-id': '96531a29-ec8c-4f4c-9c16-0fd7cc3d4c62',
        Authorization: 'Bearer b6311938-db3d-45e3-a92e-6b8049909285'
      },
      rejectUnauthorized: false,
      form: {
        grant_type: 'client_credentials',
        scope: 'accounts openid'
      }
    })

    return response.json([JSON.parse(res), JSON.parse(res2)])
  },
  async cadastro (request, response) {
    const body = request.body
    console.log(body)
    var options = {
      method: 'POST',
      uri: 'http://ec2-54-173-4-143.compute-1.amazonaws.com/api/v1/user/CadDocumento',
      body: body,
      json: true // Automatically stringifies the body to JSON
  };
   
  req(options)
      .then(function (parsedBody) {
        return response.json(parsedBody)
      })
      .catch(function (err) {
          console.log(err)
      });
    

    
  }

}
