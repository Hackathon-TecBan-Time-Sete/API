const express = require('express')

const app = express()
const cors = require('cors')

app.use(express.json())

const routes = require('./routes')
app.use(cors({
  credentials: true,
  origin: true
}))

app.use(routes)

module.exports = app
