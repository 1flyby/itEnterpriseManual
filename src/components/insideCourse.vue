<template>
	<v-container fluid  class='ma-0 pa-0'>
	<div>Пользователь {{ $route.params.courseId }}</div>
	</v-container>
</template>

<script>

import axios from 'axios'
var transferedCourseData,transferedModulesData;
export default {
	name: 'insideCourse',
	created() {
		transferedCourseData = this.$route.params.data,
		transferedCourseData.backgroundColor = '#00796B'
		console.log(transferedCourseData);
		runWebCalculation({ 
			serviceName: '_LMS.COURSES.GETMODULES',
			parameters: {courseId: transferedCourseData.courseId},
			onSuccess: function(data) {
				transferedModulesData = data.modules;
				console.log(transferedModulesData);
			}
		});
	},    
	data: () => ({
		courseData: transferedCourseData,
		modulesData: transferedModulesData,
		lessons: [
			{
				action: 'local_activity',
				title: 'Attractions',
				items: [
					{ title: 'List Item' },
					{ title: 'List Item' },
					{ title: 'List Item' }
				]
			}
		]
	}),
	// определяйте методы в объекте `methods`
  methods: {
    greet: function () {
      console.log(this);
    }
  }
}

function runWebCalculation (params) {
	axios({
		method: 'post',
		url: 'https://m.it.ua/ws/webservice.asmx/ExecuteEx?pureJSON=',
		data: {
			calcId: params.serviceName,
			args: JSON.stringify(params.parameters),
			ticket: ''
		}
	})
	.then(function (response) {
		// handle success
		params.onSuccess(response.data);
	})
	.catch(function (error) {
		// handle error
		console.log(error);
		if(params.onError)
		{
			params.onError(error);
		}
	})
	.then(function () {
		// always executed
		if(params.finnaly)
		{
			params.finnaly();
		}
	});
}

</script>

<style scoped>

#favIcon {
	margin: 0px 0px 6px 8px;
	-webkit-touch-callout: none; /* iOS Safari */
	-webkit-user-select: none; /* Safari */
	-khtml-user-select: none; /* Konqueror HTML */
	-moz-user-select: none; /* Firefox */
	-ms-user-select: none; /* Internet Explorer/Edge */
	user-select: none;
}
.roleBtn {
	transform: scale(.9);
}
.lvlBtn {
	transform: scale(.9);
}
.roleBtn,.lvlBtn {
	font-size: 13px;
	color: rgb(120,120,120) !important;
}
.v-card--hover {
	cursor: default !important;
}
.cardTitle,.v-card__media {
	cursor: pointer;
}
</style>
