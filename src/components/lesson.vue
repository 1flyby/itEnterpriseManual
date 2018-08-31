<template>
	<v-container fluid  class='ma-0 pa-0'>
		<v-layout align-center justify-start row fill-height>
			<v-flex xs12 class='white'>
				<v-breadcrumbs>
					<v-icon slot="divider">chevron_right</v-icon>
						<v-breadcrumbs-item	v-for="item in items"	:disabled="item.disabled" :key="item.text" style='color: red !important'>
							{{ item.text }}
						</v-breadcrumbs-item>
					</v-breadcrumbs>
				<v-divider/>
			</v-flex>	
		</v-layout>
		<v-layout align-center justify-center row fill-height>
			<v-flex xs8 class='my-5'>
				<v-card class='pa-5'>
					<h1 class='display-1 font-weight-regular pb-3'>{{lesson}}</h1>
					<h2 class='headline font-weight-regular pb-2'>Privacy as a Fundamental Right</h2>
					<p>
						For several decades, Europe has been a trailblazer on issues of privacy and data protection. Now, the European Union (EU) is again breaking new ground with the passage of a comprehensive privacy law called the General Data Protection Regulation (GDPR). If your business collects, stores, or uses personal information about European residents, then the GDPR can have a profound impact on your business processes.
					</p>

					<p>
						A belief in the fundamental right to privacy has been deeply ingrained in European culture since the end of World War II. One of the world’s first major privacy laws encapsulated that belief: the EU’s Data Protection Directive, adopted in 1995. The directive required companies and governments to be transparent about the personal data they process, have a legitimate purpose for their use of that data, and exercise care in handling data.
					</p>

				</v-card>
			</v-flex>
		</v-layout>
	</v-container>
</template>

<script>
var courseId, courseName, moduleId, moduleName, lessonName;
export default {
	name: 'lesson',
	beforeCreate() {
		lessonName = this.$route.params.lessonData.name;
		courseId = this.$route.params.courseId;
		courseName = this.$route.params.courseName;
		moduleId = this.$route.params.moduleId;
		moduleName = this.$route.params.moduleName;
		console.log(courseName, moduleName, lessonName);
	},
	data: () => ({
		lesson: lessonName,
		items: [
		{
			text: courseName,
			disabled: false
		},
		{
			text: moduleName,
			disabled: false
		},
		{
			text: lessonName,
			disabled: false
		}
	]
	})
}
</script>

<style scoped>
.v-breadcrumbs__item {
	color: red !important;
}
</style>

