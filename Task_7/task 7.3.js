let storage = {
    stor = [],
}

storage.GetAll = function(){
    return this.stor;
}

storage.Set = function(data){
    this.stor.push(data);
}

storage.GetById = function(id){
    var result;

    for (let i = 0; i < this.stor.length; i++){
        if (this.stor[i].id == id){
            return this.stor[i];
        }
    }
}

storage.DeleteById = function(id){
    var result;

    for (let i = 0; i < this.stor.length; i++){
        if (this.stor[i].id == id){
            this.stor[i] = null;
        }
    }
}

storage.DeleteById = function(id, data){
    var result;

    for (let i = 0; i < this.stor.length; i++){
        if (this.stor[i].id == id){
            this.stor[i] = data;
        }
    }
}