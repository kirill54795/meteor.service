import { ref } from 'vue'
import { defineStore } from 'pinia'
import axios from "axios";
import type { IApiStore } from "~/shared/interfaces/api";
import type { IFormSelectOption } from "~/shared/ui/FormSelect";


export const useMeteorsInfoStore = defineStore('meteorsInfo', (): IApiStore<{}> => {
  const data = ref([])
  const loading = ref(true)
  const error = ref('')


  axios.get('/api/meteors?queries').then((response) => {
    data.value =  response.data
  }).catch((e) => {
    error.value = e?.message
  }).finally(() => loading.value = false)
  // TODO: add getMeteorsInfo
  return { data, loading, error }
})


export const useMeteorClassStore = defineStore('meteorClass', (): IApiStore<IFormSelectOption> => {
  const data = ref([])
  const loading = ref(true)
  const error = ref('')

  axios.get('api/meteor/classes').then((response) => {
    //TODO: check select
    data.value =  response.data.map(({id, name}) => ({label: name, value: id}))
  }).catch((e) => {
    error.value = e?.message
  }).finally(() => loading.value = false)

  return { data, loading, error }
})
