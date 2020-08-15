using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
    {

        Type classType = Type.GetType(investigatedClass);


        FieldInfo[] classFields = classType.GetFields
            (BindingFlags.Instance
            | BindingFlags.Static
            | BindingFlags.NonPublic
            | BindingFlags.Public);

        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"Class under investigation: {investigatedClass}");

        Object classInstance = Activator.CreateInstance(classType, new object[] { });
        var fields = classFields.Where(f => requestedFields.Contains(f.Name));

        foreach (var field in fields)
        {
            builder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return builder.ToString().TrimEnd();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        StringBuilder builder = new StringBuilder();
        var targetType = Type.GetType(className);

        FieldInfo[] fields = targetType.GetFields(BindingFlags.Instance | BindingFlags.Static |
            BindingFlags.Public);

        foreach (var field in fields)
        {
            builder.AppendLine($"{field.Name} must be private!");
        }

        MethodInfo[] pulbicMethods = targetType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] nonpulbicMethods = targetType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (var method in nonpulbicMethods.Where(m => m.Name.StartsWith("get")))
        {
            builder.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in pulbicMethods.Where(m => m.Name.StartsWith("set")))
        {
            builder.AppendLine($"{method.Name} have to be private!");
        }

        return builder.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        StringBuilder builder = new StringBuilder();

        var targetType = Type.GetType(className);

        MethodInfo[] methodInfo = targetType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        builder.AppendLine($"All Private Methods of Class: {className}");
        builder.AppendLine($"Base Class: {targetType.BaseType.Name}");

        foreach (var method in methodInfo)
        {
            builder.AppendLine(method.Name);
        }

        return builder.ToString().TrimEnd();
    }

    public string CollectGettersAndSetters(string className)
    {
        StringBuilder builder = new StringBuilder();

        var targetType = Type.GetType(className);

        MethodInfo[] methodInfo = targetType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        var methodsWithSetters = methodInfo.Where(x => x.Name.StartsWith("set"));
        var methodsWithGetters = methodInfo.Where(x => x.Name.StartsWith("get"));

        foreach (var method in methodsWithGetters)
        {
            builder.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in methodsWithSetters)
        {
            builder.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return builder.ToString().Trim();
    }
}

