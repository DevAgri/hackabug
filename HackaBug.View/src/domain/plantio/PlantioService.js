export default class PlantioService {
  constructor (resource) {
    this.resource = resource
  }

  load () {
    return this.resource.get('plantio')
    .then(function (res) { return res.data }, function (err) {
      console.log(err)
      throw new Error('Erro')
    })
  }
  add (plantio) {
    return this.resource.post('plantio', { plantio })
  }
  remove (id) {
    return this.resource.delete('plantio', { 'id': id })
  }
}
