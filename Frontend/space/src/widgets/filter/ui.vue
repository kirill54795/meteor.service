<script setup lang="ts">
import { FormSelect, FormInput } from '~/shared/ui'
import { meteorsModel } from "$/meteors";
import { dateModel } from "$/date";
import { storeToRefs } from 'pinia'
import { useForm } from "vee-validate";

const { data: classes, loading: classesLoading, error: classesError } =  storeToRefs(meteorsModel.useMeteorClassStore())
const { data: dateList, loading: dateListLoading, error: dateListError } =  storeToRefs(dateModel.useDateStore())

const error = classesError || dateListError

//TODO: include validation lib.
const { handleSubmit, resetForm } = useForm(
);

const onSubmit = handleSubmit(values => {

  console.log(values);
});
</script>

<template>
  <form @submit="onSubmit">
    <FormSelect label="From" name="from" v-bind:options="dateList" placeholder="from" />
    <FormSelect label="To" name="to" v-bind:options="dateList" placeholder="to" />
    <FormSelect label="Class" name="class" v-bind:options="classes" placeholder="class" />
    <FormInput label="Name" name="name"  placeholder="name" />
    <a-button type="primary" html-type="submit">Apply</a-button>
    <a-button @click="resetForm">Reset</a-button>
  </form>
  <span>{{error}}</span>
</template>

<style scoped>
  form {
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr auto auto;
    align-items: center;
    justify-content: center;
    gap: 5px;
    width: 100%;
  }
</style>