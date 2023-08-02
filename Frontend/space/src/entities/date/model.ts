import { ref } from 'vue'
import { defineStore } from 'pinia'
import axios from "axios";
import type { IApiStore } from "~/shared/interfaces/api";
import type { IFormSelectOption } from "~/shared/ui/FormSelect";


export const useDateStore = defineStore('date', (): IApiStore<IFormSelectOption> => {
  const data = ref([])
  const loading = ref(true)
  const error = ref('')

  axios.get('/users').then((response) => {
    data.value =  response.data.map(({id, name}) => ({label: name, value: id}))
  }).catch((e) => {
    error.value = e?.message
  }).finally(() => loading.value = false)

  return { data, loading, error }
})
