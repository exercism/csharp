Dir.glob('exercises/practice/**/*.csproj') do |file| 
  next unless File.exists?(File.join(File.dirname(file), '.meta', 'Generator.tpl'))

  generator_file = File.join(__dir__, 'generators.deprecated', 'Exercises', 'Generators', "#{File.basename(file, '.csproj')}.cs")
  next unless File.exists?(generator_file)

  File.delete(generator_file)
end