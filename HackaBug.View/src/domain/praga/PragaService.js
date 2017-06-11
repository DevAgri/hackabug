export default class PragaService {
  constructor (resource) {
    this.resource = resource
  }

  load () {
    return this.resource.get('pragas')
    .then(function (res) { return res.data }, function (err) {
      console.log(err)
      throw new Error('Erro')
    })
  }
  add (nomePraga) {
    return this.resource.post('pragas', { 'nome': nomePraga })
  }
  remove (id) {
    return this.resource.delete(`pragas/${id}`)
  }
}
