export default class CulturaService {
  constructor (resource) {
    this.resource = resource
  }

  load () {
    return this.resource.get('culturas')
    .then(function (res) { return res.data }, function (err) {
      console.log(err)
      throw new Error('Erro')
    })
  }
  add (nomePraga) {
    return this.resource.post('culturas', { 'nome': nomePraga })
  }
  remove (id) {
    return this.resource.delete('culturas', { 'id': id })
  }
}
