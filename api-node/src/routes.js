const { Router } = require('express')
const apiTecban = require('./controllers/apiTecban')
const routes = Router()

routes.get('/', (req, res) => {
  res.send(`<h1><a href="https://api-agroban.herokuapp.com/products"> lista de produtos</a></h1><br>
  <h1><a href="https://api-agroban.herokuapp.com/accounts">lista de contas </a></h1> `)
})
routes.get('/accounts', apiTecban.account)
routes.get('/products', apiTecban.products)

routes.post('/cadastro', apiTecban.cadastro)

module.exports = routes
